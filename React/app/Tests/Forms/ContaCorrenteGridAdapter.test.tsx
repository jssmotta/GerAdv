// ContaCorrenteGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { ContaCorrenteGridAdapter } from '@/app/GerAdv_TS/ContaCorrente/Adapter/ContaCorrenteGridAdapter';
// Mock ContaCorrenteGrid component
jest.mock('@/app/GerAdv_TS/ContaCorrente/Crud/Grids/ContaCorrenteGrid', () => () => <div data-testid='contacorrente-grid-mock' />);
describe('ContaCorrenteGridAdapter', () => {
  it('should render ContaCorrenteGrid component', () => {
    const adapter = new ContaCorrenteGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('contacorrente-grid-mock')).toBeInTheDocument();
  });
});