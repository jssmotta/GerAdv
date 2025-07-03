// TipoContatoCRMGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { TipoContatoCRMGridAdapter } from '@/app/GerAdv_TS/TipoContatoCRM/Adapter/TipoContatoCRMGridAdapter';
// Mock TipoContatoCRMGrid component
jest.mock('@/app/GerAdv_TS/TipoContatoCRM/Crud/Grids/TipoContatoCRMGrid', () => () => <div data-testid='tipocontatocrm-grid-mock' />);
describe('TipoContatoCRMGridAdapter', () => {
  it('should render TipoContatoCRMGrid component', () => {
    const adapter = new TipoContatoCRMGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('tipocontatocrm-grid-mock')).toBeInTheDocument();
  });
});