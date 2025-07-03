// RegimeTributacaoGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { RegimeTributacaoGridAdapter } from '@/app/GerAdv_TS/RegimeTributacao/Adapter/RegimeTributacaoGridAdapter';
// Mock RegimeTributacaoGrid component
jest.mock('@/app/GerAdv_TS/RegimeTributacao/Crud/Grids/RegimeTributacaoGrid', () => () => <div data-testid='regimetributacao-grid-mock' />);
describe('RegimeTributacaoGridAdapter', () => {
  it('should render RegimeTributacaoGrid component', () => {
    const adapter = new RegimeTributacaoGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('regimetributacao-grid-mock')).toBeInTheDocument();
  });
});