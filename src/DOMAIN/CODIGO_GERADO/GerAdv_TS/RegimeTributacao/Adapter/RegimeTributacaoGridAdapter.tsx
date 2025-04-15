"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import RegimeTributacaoGrid from "@/app/GerAdv_TS/RegimeTributacao/Crud/Grids/RegimeTributacaoGrid";

export class RegimeTributacaoGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <RegimeTributacaoGrid />;
    }
}