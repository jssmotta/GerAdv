import { IViaRecebimento } from "../ViaRecebimento/Interfaces/interface.ViaRecebimento";
export interface ViaRecebimento
{
    id: number;
	nome : string;
}

export function ViaRecebimentoEmpty(): IViaRecebimento {
// 20250125
    return {
        id: 0,
		nome: '',
    };
}
