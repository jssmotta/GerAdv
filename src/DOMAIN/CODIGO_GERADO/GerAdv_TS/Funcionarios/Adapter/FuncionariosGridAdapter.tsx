"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import FuncionariosGrid from "@/app/GerAdv_TS/Funcionarios/Crud/Grids/FuncionariosGrid";

export class FuncionariosGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <FuncionariosGrid />;
    }
}