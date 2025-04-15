"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import FornecedoresGrid from "@/app/GerAdv_TS/Fornecedores/Crud/Grids/FornecedoresGrid";

export class FornecedoresGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <FornecedoresGrid />;
    }
}