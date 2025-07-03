// TipoCompromissoGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { TipoCompromissoGridAdapter } from '@/app/GerAdv_TS/TipoCompromisso/Adapter/TipoCompromissoGridAdapter';
// Mock TipoCompromissoGrid component
jest.mock('@/app/GerAdv_TS/TipoCompromisso/Crud/Grids/TipoCompromissoGrid', () => () => <div data-testid='tipocompromisso-grid-mock' />);
describe('TipoCompromissoGridAdapter', () => {
  it('should render TipoCompromissoGrid component', () => {
    const adapter = new TipoCompromissoGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('tipocompromisso-grid-mock')).toBeInTheDocument();
  });
});