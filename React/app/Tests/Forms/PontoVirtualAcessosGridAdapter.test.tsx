// PontoVirtualAcessosGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { PontoVirtualAcessosGridAdapter } from '@/app/GerAdv_TS/PontoVirtualAcessos/Adapter/PontoVirtualAcessosGridAdapter';
// Mock PontoVirtualAcessosGrid component
jest.mock('@/app/GerAdv_TS/PontoVirtualAcessos/Crud/Grids/PontoVirtualAcessosGrid', () => () => <div data-testid='pontovirtualacessos-grid-mock' />);
describe('PontoVirtualAcessosGridAdapter', () => {
  it('should render PontoVirtualAcessosGrid component', () => {
    const adapter = new PontoVirtualAcessosGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('pontovirtualacessos-grid-mock')).toBeInTheDocument();
  });
});