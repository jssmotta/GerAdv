// TipoOrigemSucumbenciaGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { TipoOrigemSucumbenciaGridAdapter } from '@/app/GerAdv_TS/TipoOrigemSucumbencia/Adapter/TipoOrigemSucumbenciaGridAdapter';
// Mock TipoOrigemSucumbenciaGrid component
jest.mock('@/app/GerAdv_TS/TipoOrigemSucumbencia/Crud/Grids/TipoOrigemSucumbenciaGrid', () => () => <div data-testid='tipoorigemsucumbencia-grid-mock' />);
describe('TipoOrigemSucumbenciaGridAdapter', () => {
  it('should render TipoOrigemSucumbenciaGrid component', () => {
    const adapter = new TipoOrigemSucumbenciaGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('tipoorigemsucumbencia-grid-mock')).toBeInTheDocument();
  });
});