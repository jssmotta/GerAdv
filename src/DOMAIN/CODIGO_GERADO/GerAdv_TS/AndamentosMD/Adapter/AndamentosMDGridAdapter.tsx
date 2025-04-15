"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import AndamentosMDGrid from "@/app/GerAdv_TS/AndamentosMD/Crud/Grids/AndamentosMDGrid";

export class AndamentosMDGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <AndamentosMDGrid />;
    }
}