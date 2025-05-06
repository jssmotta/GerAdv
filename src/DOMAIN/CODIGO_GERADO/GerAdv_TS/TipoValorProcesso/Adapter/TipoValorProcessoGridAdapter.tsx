"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import TipoValorProcessoGrid from "@/app/GerAdv_TS/TipoValorProcesso/Crud/Grids/TipoValorProcessoGrid";

export class TipoValorProcessoGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <TipoValorProcessoGrid />;
    }
}