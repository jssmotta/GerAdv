"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import PosicaoOutrasPartesGrid from "@/app/GerAdv_TS/PosicaoOutrasPartes/Crud/Grids/PosicaoOutrasPartesGrid";

export class PosicaoOutrasPartesGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <PosicaoOutrasPartesGrid />;
    }
}