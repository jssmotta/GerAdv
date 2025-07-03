// PontoVirtualGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { PontoVirtualGridAdapter } from '@/app/GerAdv_TS/PontoVirtual/Adapter/PontoVirtualGridAdapter';
// Mock PontoVirtualGrid component
jest.mock('@/app/GerAdv_TS/PontoVirtual/Crud/Grids/PontoVirtualGrid', () => () => <div data-testid='pontovirtual-grid-mock' />);
describe('PontoVirtualGridAdapter', () => {
  it('should render PontoVirtualGrid component', () => {
    const adapter = new PontoVirtualGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('pontovirtual-grid-mock')).toBeInTheDocument();
  });
});