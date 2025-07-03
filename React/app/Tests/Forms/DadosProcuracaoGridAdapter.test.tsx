// DadosProcuracaoGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { DadosProcuracaoGridAdapter } from '@/app/GerAdv_TS/DadosProcuracao/Adapter/DadosProcuracaoGridAdapter';
// Mock DadosProcuracaoGrid component
jest.mock('@/app/GerAdv_TS/DadosProcuracao/Crud/Grids/DadosProcuracaoGrid', () => () => <div data-testid='dadosprocuracao-grid-mock' />);
describe('DadosProcuracaoGridAdapter', () => {
  it('should render DadosProcuracaoGrid component', () => {
    const adapter = new DadosProcuracaoGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('dadosprocuracao-grid-mock')).toBeInTheDocument();
  });
});