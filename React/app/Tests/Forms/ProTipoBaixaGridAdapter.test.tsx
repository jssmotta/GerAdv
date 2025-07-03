// ProTipoBaixaGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { ProTipoBaixaGridAdapter } from '@/app/GerAdv_TS/ProTipoBaixa/Adapter/ProTipoBaixaGridAdapter';
// Mock ProTipoBaixaGrid component
jest.mock('@/app/GerAdv_TS/ProTipoBaixa/Crud/Grids/ProTipoBaixaGrid', () => () => <div data-testid='protipobaixa-grid-mock' />);
describe('ProTipoBaixaGridAdapter', () => {
  it('should render ProTipoBaixaGrid component', () => {
    const adapter = new ProTipoBaixaGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('protipobaixa-grid-mock')).toBeInTheDocument();
  });
});