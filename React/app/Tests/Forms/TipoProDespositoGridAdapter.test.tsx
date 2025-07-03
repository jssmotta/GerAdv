// TipoProDespositoGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { TipoProDespositoGridAdapter } from '@/app/GerAdv_TS/TipoProDesposito/Adapter/TipoProDespositoGridAdapter';
// Mock TipoProDespositoGrid component
jest.mock('@/app/GerAdv_TS/TipoProDesposito/Crud/Grids/TipoProDespositoGrid', () => () => <div data-testid='tipoprodesposito-grid-mock' />);
describe('TipoProDespositoGridAdapter', () => {
  it('should render TipoProDespositoGrid component', () => {
    const adapter = new TipoProDespositoGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('tipoprodesposito-grid-mock')).toBeInTheDocument();
  });
});