"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import EnderecosGrid from "@/app/GerAdv_TS/Enderecos/Crud/Grids/EnderecosGrid";

export class EnderecosGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <EnderecosGrid />;
    }
}