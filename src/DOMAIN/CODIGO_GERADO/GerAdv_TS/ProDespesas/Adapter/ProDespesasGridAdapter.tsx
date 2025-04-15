"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import ProDespesasGrid from "@/app/GerAdv_TS/ProDespesas/Crud/Grids/ProDespesasGrid";

export class ProDespesasGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <ProDespesasGrid />;
    }
}