'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import OutrasPartesClienteGrid from '@/app/GerAdv_TS/OutrasPartesCliente/Crud/Grids/OutrasPartesClienteGrid';
export class OutrasPartesClienteGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <OutrasPartesClienteGrid />;
  }
}