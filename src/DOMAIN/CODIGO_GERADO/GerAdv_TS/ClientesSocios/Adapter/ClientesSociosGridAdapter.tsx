"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import ClientesSociosGrid from "@/app/GerAdv_TS/ClientesSocios/Crud/Grids/ClientesSociosGrid";

export class ClientesSociosGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <ClientesSociosGrid />;
    }
}