// GruposEmpresasGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { GruposEmpresasGridAdapter } from '@/app/GerAdv_TS/GruposEmpresas/Adapter/GruposEmpresasGridAdapter';
// Mock GruposEmpresasGrid component
jest.mock('@/app/GerAdv_TS/GruposEmpresas/Crud/Grids/GruposEmpresasGrid', () => () => <div data-testid='gruposempresas-grid-mock' />);
describe('GruposEmpresasGridAdapter', () => {
  it('should render GruposEmpresasGrid component', () => {
    const adapter = new GruposEmpresasGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('gruposempresas-grid-mock')).toBeInTheDocument();
  });
});