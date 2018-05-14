using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UdpPacks;
using System.Threading;

namespace WinCommunication
{
    public partial class frmCommunication : Form
    {
        public frmCommunication()
        {
            InitializeComponent();
        }
        Socket client;
        IPEndPoint Iep;
        string msg = "";

        int count = 0;
        long bl = 0;
        string Names = "";
        List<UdpPack> ListUdp = null;
        //连接事件
        private void btnBin_Click(object sender, EventArgs e)
        {
            try
            {
                Iep = new IPEndPoint(IPAddress.Parse(txtLocalIP.Text), int.Parse(txtk1.Text));
                client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                client.Bind(Iep);
                rtbMsgList.AppendText("成功运行......\n");
                ListUdp = new List<UdpPack>();
                if (!string.IsNullOrEmpty(txtLocalIP.Text))
                {
                    new Task(() =>
                    {
                        #region 循环接收数据
                        while (true)
                        {
                            try
                            {
                                EndPoint remote = new IPEndPoint(IPAddress.Any, 0);
                                byte[] by = new byte[20480];
                                int recv = client.ReceiveFrom(by, ref remote);
                                byte[] ort = new byte[recv];
                                Buffer.BlockCopy(by, 1, ort, 0, recv);
                                //判断接收的字节数组是字符串还是文件
                                if (by[0] == 0)
                                {
                                    #region 接收字符串
                                    string name = string.Format("{1}", remote, Encoding.UTF8.GetString(ort, 0, recv));
                                    Action action = new Action(() =>
                                    {
                                        rtbMsgList.AppendText(name + "\n");
                                        frmPopups po = new frmPopups(name);
                                        po.ShowDialog();
                                    });
                                    this.Invoke(action);
                                    #endregion
                                }
                                else
                                {
                                    #region 接收文件保存
                                    object obj = new object();
                                    byte[] dt = new byte[by.Length - 1];
                                    Buffer.BlockCopy(by, 1, dt, 0, by.Length - 1);
                                    MemoryStream ms = new MemoryStream(dt);
                                    ms.Position = 0;
                                    BinaryFormatter formatter = new BinaryFormatter();
                                    obj = formatter.Deserialize(ms);//把内存流反序列成对象    
                                    ms.Close();
                                    UdpPack pa = (UdpPack)obj;
                                    count = pa.count;
                                    bl = pa.bl;
                                    Names = Encoding.UTF8.GetString(pa.packname, 0, pa.packname.Length);
                                    bool bol = true;
                                    if (ListUdp.Count == 0)
                                    {
                                        ListUdp.Add(pa);
                                    }
                                    else
                                    {
                                        foreach (var item in ListUdp)
                                        {
                                            if (pa.id == item.id)
                                            {
                                                bol = false;
                                            }
                                        }
                                        if (bol)
                                        {
                                            ListUdp.Add(pa);
                                        }
                                    }
                                    if (count != 0)
                                    {
                                        if (ListUdp.Count >= count)
                                        {
                                            if (MessageBox.Show("是否接收文件 " + Names, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                                            {
                                                Thread InvokeThread = new Thread(new ThreadStart(Preservation));
                                                InvokeThread.SetApartmentState(ApartmentState.STA);
                                                InvokeThread.Start();
                                                InvokeThread.Join();
                                            }
                                        }
                                    }
                                    #endregion
                                }
                            }
                            catch (Exception ex)
                            {
                                Action action = new Action(() =>
                                {
                                    rtbMsgList.AppendText(ex.Message);
                                });
                                this.Invoke(action);
                                break;
                            }
                        } 
                        #endregion
                    }).Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public string GetClientLocalIPv4Address()
        {
            string strLocalIP = string.Empty;
            try
            {
                //获取IPv4地址
                IPHostEntry iPHost = Dns.Resolve(Dns.GetHostName());
                //获取IPv6地址
                //IPHostEntry iPHost = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress iPAddress = iPHost.AddressList[0];
                strLocalIP = iPAddress.ToString();
                return strLocalIP;
            }
            catch
            {

                return "unkown";
            }
        }
        /// <summary>
        /// 将文件保存在选择的路径下
        /// </summary>
        private void Preservation()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "";
            sfd.InitialDirectory = @"C:\";
            string[] ors = Names.Split('.');
            //sfd.Filter ="."+ors[1];
            sfd.Filter = ors[1] + "文件|." + ors[1];//文件的类型
            sfd.FileName = Names;//文件的名称
            sfd.ShowDialog();
            using (FileStream fsWrite = new FileStream(Names, FileMode.OpenOrCreate, FileAccess.Write))
            {
                byte[] de = new byte[bl];
                for (int i = 0; i < count; i++)
                {
                    foreach (var item in ListUdp)
                    {
                        if (item.id == i + 1)
                        {
                            if (bl < 6144)
                            {
                                Buffer.BlockCopy(item.pack, 0, de, i, (int)bl);
                            }
                            else
                            {
                                Buffer.BlockCopy(item.pack, 0, de, i * 6144, item.pack.Length - 1);
                            }
                        }
                    }
                }
               InvokeMsg( "正在接收文件");
               File.WriteAllBytes(sfd.FileName.ToString(), de);
               InvokeMsg ( "文件接收成功");
            }
        }
        private void InvokeMsg(string msg)
        {
            Action action = () =>
            {
                label2.Text=msg;
            };
            this.Invoke(action);
        }
        private void bntSend_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtProcessIP.Text))
            {
                try
                {
                    IPEndPoint remote = new IPEndPoint(IPAddress.Parse(txtProcessIP.Text),int.Parse(txtk2.Text));
                    msg = string.Format("{0}\n\t{1}\n", txtProcessIP.Text, txtMsg.Text);
                    byte[] fe = Encoding.UTF8.GetBytes(msg);
                    byte[] of = new byte[fe.Length + 1];
                    Buffer.BlockCopy(fe, 0, of, 1, fe.Length);
                    client.SendTo(of, remote);
                    msg = string.Format("我\n\t{0}", txtMsg.Text);
                    txtMsg.Text = "";
                }
                catch (Exception ex)
                {
                    rtbMsgList.AppendText(ex.Message);
                    return;
                }
                rtbMsgList.AppendText(msg + "\n");
            }
            else
                MessageBox.Show("请输入对方的IP地址！");
        }
        private void txtMsg_DragDrop(object sender, DragEventArgs e)
        {
                //sender.GetType().Name;
                string name = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
                try
                {
                    string[] strName = name.Split('\\');
                    string strPack = strName[strName.Count() - 1];
                    byte[] packName = Encoding.UTF8.GetBytes(strPack);
                    FileStream fs = new FileStream(name, FileMode.Open, FileAccess.Read);
                    byte[] pack = new byte[fs.Length];
                    fs.Read(pack, 0, (int)fs.Length);
                    long fd = 6144;
                    List<UdpPack> ListUdp = new List<UdpPack>();
                    UdpPack udpPack = null;
                    int count = pack.Length / 6144;
                    if (pack.Length < 6144)
                    {
                        count = 1;
                    }
                    byte[] ps = null;
                    for (int i = 0; i < count; i++)
                    {
                        udpPack = new UdpPack();//19619565/61440
                        ps = new byte[fd];
                        if (pack.Length - (fd * i) > fd)
                        {
                            Array.Copy(pack, i * 6144, ps, 0, fd);
                        }
                        else
                        {
                            Array.Copy(pack, i * 6144, ps, 0, pack.Length - (fd * i));
                        }
                        udpPack.id = i + 1;
                        udpPack.count = count;
                        udpPack.pack = ps;
                        udpPack.bl = pack.Length;
                        udpPack.packname = packName;
                        ListUdp.Add(udpPack);
                    }
                    int position = 0;
                    foreach (var item in ListUdp)
                    {
                        MemoryStream ms = new MemoryStream();
                        BinaryFormatter formatter = new BinaryFormatter();
                        formatter.Serialize(ms, (object)item);
                        ms.Position = 0;
                        byte[] bytes = ms.GetBuffer();
                        ms.Read(bytes, 0, bytes.Length);
                        ms.Close();
                        IPEndPoint remote = new IPEndPoint(IPAddress.Parse(txtProcessIP.Text), int.Parse(txtk2.Text));
                        byte[] bytets = new byte[bytes.Length + 1];
                        bytets[0] = 1;
                        Buffer.BlockCopy(bytes, 0, bytets, 1, bytes.Length);
                        //client.SendTo(bytets, remote);
                        client.BeginSendTo(bytets, 0, bytets.Length, SocketFlags.None, remote, async =>
                        {
                            int send = client.EndSendTo(async);
                        }, null);
                        Thread.Sleep(100);
                        position++;
                        ShowProgressSchedule(ListUdp.Count, position);
                        //label2.Text = "文件发送成功！";
                        InvokeMsg("文件发送成功");
                    }
                }
                catch (Exception)
                {
                    throw;
                }
        }
        //定义一个委托
        delegate void ShowProgressScheduleDele(int totalSize,int position);
        private void ShowProgressSchedule(int totalSize,int position)
        {
            // 判断是否在线程中访问   chinese      
            if (!this.progressBar1.InvokeRequired)
            {
                // 不是的话直接操作控件
                this.progressBar1.Maximum = (Int32)totalSize;
                this.progressBar1.Value = (Int32)position;
            }
            else
            {
                // 是的话启用delegate访问
                ShowProgressScheduleDele showProgress = new ShowProgressScheduleDele(ShowProgressSchedule);
                // 如使用Invoke会等到函数调用结束，而BeginInvoke不会等待直接往后走
                this.BeginInvoke(showProgress, new object[] { });
            }
        }
        private void txtMsg_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
    }
}
