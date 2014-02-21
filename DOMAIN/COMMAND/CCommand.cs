using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CCommand : CCode
{
	public int idx { get; set; }
	public string tb_name { get; set; }
	public int tb_idx { get; set; }
	public string ord_type { get; set; }
	public string ord_emp_no { get; set; }
	public string ord_emp_name { get; set; }
	public string subject { get; set; }
	public string content { get; set; }
	public string reg_ip { get; set; }
	public int hit { get; set; }
	public DateTime reg_date { get; set; }
	public DateTime mod_date { get; set; }
	public string is_delete { get; set; }
	public string is_secret { get; set; }
}