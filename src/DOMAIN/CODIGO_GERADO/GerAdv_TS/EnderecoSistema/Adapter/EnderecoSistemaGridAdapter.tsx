"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import EnderecoSistemaGrid from "@/app/GerAdv_TS/EnderecoSistema/Crud/Grids/EnderecoSistemaGrid";

export class EnderecoSistemaGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <EnderecoSistemaGrid />;
    }
}