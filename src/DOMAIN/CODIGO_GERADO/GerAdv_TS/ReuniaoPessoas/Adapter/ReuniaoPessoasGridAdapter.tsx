"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import ReuniaoPessoasGrid from "@/app/GerAdv_TS/ReuniaoPessoas/Crud/Grids/ReuniaoPessoasGrid";

export class ReuniaoPessoasGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <ReuniaoPessoasGrid />;
    }
}