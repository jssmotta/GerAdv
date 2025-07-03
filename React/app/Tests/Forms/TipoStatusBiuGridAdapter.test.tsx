// TipoStatusBiuGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { TipoStatusBiuGridAdapter } from '@/app/GerAdv_TS/TipoStatusBiu/Adapter/TipoStatusBiuGridAdapter';
// Mock TipoStatusBiuGrid component
jest.mock('@/app/GerAdv_TS/TipoStatusBiu/Crud/Grids/TipoStatusBiuGrid', () => () => <div data-testid='tipostatusbiu-grid-mock' />);
describe('TipoStatusBiuGridAdapter', () => {
  it('should render TipoStatusBiuGrid component', () => {
    const adapter = new TipoStatusBiuGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('tipostatusbiu-grid-mock')).toBeInTheDocument();
  });
});