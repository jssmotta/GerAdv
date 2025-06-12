'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import ClientesGrid from '@/app/GerAdv_TS/Clientes/Crud/Grids/ClientesGrid';
export class ClientesGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <ClientesGrid />;
  }
}