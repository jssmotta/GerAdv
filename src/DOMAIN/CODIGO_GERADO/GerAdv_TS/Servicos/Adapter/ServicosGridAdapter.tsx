"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import ServicosGrid from "@/app/GerAdv_TS/Servicos/Crud/Grids/ServicosGrid";

export class ServicosGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <ServicosGrid />;
    }
}