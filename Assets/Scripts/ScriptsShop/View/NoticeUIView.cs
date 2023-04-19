using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class NoticeUIView : MonoBehaviour
{
    public static NoticeUIView Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI _label;
    
    private Animator _animator;

    private void Awake()
    {
        if (Instance != this && Instance != null)
            Destroy(gameObject);
        Instance = this;
        
        _animator = GetComponent<Animator>();
    }

    public void Show(string message)
    {
        _label.text = message;
        _animator.SetTrigger("NoticeShow");
        StartCoroutine("Close");
    }

    private IEnumerator Close()
    {
        yield return new WaitForSeconds(4f);
        _animator.SetTrigger("NoticeHide");
    }
}
