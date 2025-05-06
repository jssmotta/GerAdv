"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import FuncaoGrid from "@/app/GerAdv_TS/Funcao/Crud/Grids/FuncaoGrid";

export class FuncaoGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <FuncaoGrid />;
    }
}