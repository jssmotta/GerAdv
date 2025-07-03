// LivroCaixaGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { LivroCaixaGridAdapter } from '@/app/GerAdv_TS/LivroCaixa/Adapter/LivroCaixaGridAdapter';
// Mock LivroCaixaGrid component
jest.mock('@/app/GerAdv_TS/LivroCaixa/Crud/Grids/LivroCaixaGrid', () => () => <div data-testid='livrocaixa-grid-mock' />);
describe('LivroCaixaGridAdapter', () => {
  it('should render LivroCaixaGrid component', () => {
    const adapter = new LivroCaixaGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('livrocaixa-grid-mock')).toBeInTheDocument();
  });
});