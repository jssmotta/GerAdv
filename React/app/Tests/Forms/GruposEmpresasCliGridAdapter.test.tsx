// GruposEmpresasCliGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { GruposEmpresasCliGridAdapter } from '@/app/GerAdv_TS/GruposEmpresasCli/Adapter/GruposEmpresasCliGridAdapter';
// Mock GruposEmpresasCliGrid component
jest.mock('@/app/GerAdv_TS/GruposEmpresasCli/Crud/Grids/GruposEmpresasCliGrid', () => () => <div data-testid='gruposempresascli-grid-mock' />);
describe('GruposEmpresasCliGridAdapter', () => {
  it('should render GruposEmpresasCliGrid component', () => {
    const adapter = new GruposEmpresasCliGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('gruposempresascli-grid-mock')).toBeInTheDocument();
  });
});