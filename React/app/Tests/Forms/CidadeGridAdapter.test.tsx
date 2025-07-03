// CidadeGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { CidadeGridAdapter } from '@/app/GerAdv_TS/Cidade/Adapter/CidadeGridAdapter';
// Mock CidadeGrid component
jest.mock('@/app/GerAdv_TS/Cidade/Crud/Grids/CidadeGrid', () => () => <div data-testid='cidade-grid-mock' />);
describe('CidadeGridAdapter', () => {
  it('should render CidadeGrid component', () => {
    const adapter = new CidadeGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('cidade-grid-mock')).toBeInTheDocument();
  });
});