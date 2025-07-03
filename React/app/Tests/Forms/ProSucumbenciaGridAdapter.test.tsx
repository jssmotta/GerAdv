// ProSucumbenciaGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { ProSucumbenciaGridAdapter } from '@/app/GerAdv_TS/ProSucumbencia/Adapter/ProSucumbenciaGridAdapter';
// Mock ProSucumbenciaGrid component
jest.mock('@/app/GerAdv_TS/ProSucumbencia/Crud/Grids/ProSucumbenciaGrid', () => () => <div data-testid='prosucumbencia-grid-mock' />);
describe('ProSucumbenciaGridAdapter', () => {
  it('should render ProSucumbenciaGrid component', () => {
    const adapter = new ProSucumbenciaGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('prosucumbencia-grid-mock')).toBeInTheDocument();
  });
});