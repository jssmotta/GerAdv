// BensClassificacaoGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { BensClassificacaoGridAdapter } from '@/app/GerAdv_TS/BensClassificacao/Adapter/BensClassificacaoGridAdapter';
// Mock BensClassificacaoGrid component
jest.mock('@/app/GerAdv_TS/BensClassificacao/Crud/Grids/BensClassificacaoGrid', () => () => <div data-testid='bensclassificacao-grid-mock' />);
describe('BensClassificacaoGridAdapter', () => {
  it('should render BensClassificacaoGrid component', () => {
    const adapter = new BensClassificacaoGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('bensclassificacao-grid-mock')).toBeInTheDocument();
  });
});