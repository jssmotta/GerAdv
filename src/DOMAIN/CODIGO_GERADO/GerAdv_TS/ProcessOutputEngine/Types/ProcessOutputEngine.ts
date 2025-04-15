export interface IProcessOutputEngine {
  id: number;
	nome : string;
	database : string;
	tabela : string;
	campo : string;
	valor : string;
	output : string;
	administrador : boolean;
	outputsource : number;
	disableditem : boolean;
	idmodulo : number;
	isonlyprocesso : boolean;
	myid : number;
}
