"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import GruposEmpresasCliGrid from "@/app/GerAdv_TS/GruposEmpresasCli/Crud/Grids/GruposEmpresasCliGrid";

export class GruposEmpresasCliGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <GruposEmpresasCliGrid />;
    }
}