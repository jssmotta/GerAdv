"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import AnexamentoRegistrosGrid from "@/app/GerAdv_TS/AnexamentoRegistros/Crud/Grids/AnexamentoRegistrosGrid";

export class AnexamentoRegistrosGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <AnexamentoRegistrosGrid />;
    }
}