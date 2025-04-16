"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import TribEnderecosGrid from "@/app/GerAdv_TS/TribEnderecos/Crud/Grids/TribEnderecosGrid";

export class TribEnderecosGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <TribEnderecosGrid />;
    }
}