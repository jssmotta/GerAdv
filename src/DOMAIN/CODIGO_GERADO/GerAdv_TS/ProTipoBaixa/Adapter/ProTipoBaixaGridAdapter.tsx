'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import ProTipoBaixaGrid from '@/app/GerAdv_TS/ProTipoBaixa/Crud/Grids/ProTipoBaixaGrid';
export class ProTipoBaixaGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <ProTipoBaixaGrid />;
  }
}