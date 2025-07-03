// OutrasPartesClienteGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { OutrasPartesClienteGridAdapter } from '@/app/GerAdv_TS/OutrasPartesCliente/Adapter/OutrasPartesClienteGridAdapter';
// Mock OutrasPartesClienteGrid component
jest.mock('@/app/GerAdv_TS/OutrasPartesCliente/Crud/Grids/OutrasPartesClienteGrid', () => () => <div data-testid='outraspartescliente-grid-mock' />);
describe('OutrasPartesClienteGridAdapter', () => {
  it('should render OutrasPartesClienteGrid component', () => {
    const adapter = new OutrasPartesClienteGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('outraspartescliente-grid-mock')).toBeInTheDocument();
  });
});