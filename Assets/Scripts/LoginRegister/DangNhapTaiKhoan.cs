using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
public class DangNhapTaiKhoan : MonoBehaviour
{
    public TMP_InputField user;
    public TMP_InputField passwd;
    public TextMeshProUGUI thongbao;




    public void DangNhapButton()
    {
        StartCoroutine(DangNhap());
    }

    IEnumerator DangNhap()
    {
        WWWForm form = new WWWForm();
        form.AddField("user", user.text);
        form.AddField("passwd", passwd.text);

        UnityWebRequest www = UnityWebRequest.Post("https://fpl.expvn.com/dangnhap.php", form);
        yield return www.SendWebRequest(); //chờ phản hồi từ máy chủ

        if (!www.isDone)
        {
            thongbao.text = "Kết nối không thành công";
        }
        else
        {
            string get = www.downloadHandler.text;

            if(get == "empty")
            {
                thongbao.text = "Các trường không được để trống";
            }else if(get == "" || get == null)
            {
                thongbao.text = "Tài khoản hoặc mật khẩu không đúng";
            }else if (get.Contains("Lỗi"))
            {
                thongbao.text = "không kết nối được server";
            }
            else
            {
                thongbao.text = "Đăng nhập thành công";
                PlayerPrefs.SetString("token", get);
            }

            string token = PlayerPrefs.GetString("token");
            Debug.Log(token);
        }
    }
    
}
