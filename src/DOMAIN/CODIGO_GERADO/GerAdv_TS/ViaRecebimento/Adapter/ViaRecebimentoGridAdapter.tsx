"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import ViaRecebimentoGrid from "@/app/GerAdv_TS/ViaRecebimento/Crud/Grids/ViaRecebimentoGrid";

export class ViaRecebimentoGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <ViaRecebimentoGrid />;
    }
}