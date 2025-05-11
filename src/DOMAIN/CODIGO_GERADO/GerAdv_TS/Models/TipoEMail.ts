import { ITipoEMail } from "../TipoEMail/Interfaces/interface.TipoEMail";
export interface TipoEMail
{
    id: number;
	nome : string;
}

export function TipoEMailEmpty(): ITipoEMail {
// 20250125
    return {
        id: 0,
		nome: '',
    };
}
