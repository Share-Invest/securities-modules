using Newtonsoft.Json;

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ShareInvest.Entities.Dart;

public class Disclousure
{
    [DataMember, JsonProperty("rcept_no"), StringLength(0xE)]
    public string? SerialNumber
    {
        get; set;
    }
    [DataMember, JsonProperty("rcept_dt"), StringLength(8)]
    public string? Date
    {
        get; set;
    }
    [DataMember, JsonProperty("stock_code"), StringLength(6)]
    public string? Code
    {
        get; set;
    }
    [DataMember, JsonProperty("corp_name"), StringLength(0x40)]
    public string? Name
    {
        get; set;
    }
    [DataMember, JsonProperty("corp_code"), StringLength(8)]
    public string? CorpCode
    {
        get; set;
    }
    /// <summary>
    /// [기재정정] : 본 보고서명으로 이미 제출된 보고서의 기재내용이 변경되어 제출
    /// [첨부정정] : 본 보고서명으로 이미 제출된 보고서의 첨부내용이 변경되어 제출
    /// [첨부추가] : 본 보고서명으로 이미 제출된 보고서의 첨부서류가 추가되어 제출
    /// [변경등록] : 본 보고서명으로 이미 제출된 보고서의 유동화계획이 변경되어 제출
    /// [연장결정] : 본 보고서명으로 이미 제출된 보고서의 신탁계약이 연장되어 제출
    /// [발행조건확정] : 본 보고서명으로 이미 제출된 보고서의 유가증권 발행조건이 확정되어 제출
    /// [정정명령부과] : 본 보고서에 대하여 금융감독원이 정정명령을 부과
    /// [정정제출요구] : 본 보고서에 대하여 금융감독원이 정정제출요구을 부과
    /// </summary>
    [DataMember, JsonProperty("report_nm"), StringLength(0x100)]
    public string? ReportName
    {
        get; set;
    }
    /// <summary>Y(유가), K(코스닥), N(코넥스), E(기타)</summary>
    [DataMember, JsonProperty("corp_cls"), StringLength(1)]
    public string? CorpClassification
    {
        get; set;
    }
    [DataMember, JsonProperty("flr_nm"), StringLength(0x40)]
    public string? Submitter
    {
        get; set;
    }
    /// <summary>
    /// 유 : 본 공시사항은 한국거래소 유가증권시장본부 소관
    /// 코 : 본 공시사항은 한국거래소 코스닥시장본부 소관
    /// 채 : 본 문서는 한국거래소 채권상장법인 공시사항
    /// 넥 : 본 문서는 한국거래소 코넥스시장 소관
    /// 공 : 본 공시사항은 공정거래위원회 소관
    /// 연 : 본 보고서는 연결부분을 포함
    /// 정 : 본 보고서 제출 후 정정신고가 있으니 관련 보고서를 참조
    /// 철 : 본 보고서는 철회(간주)되었으니 관련 철회신고서(철회간주안내)를 참고
    /// </summary>
    [DataMember, JsonProperty("rm"), StringLength(2)]
    public string? Remarks
    {
        get; set;
    }
}