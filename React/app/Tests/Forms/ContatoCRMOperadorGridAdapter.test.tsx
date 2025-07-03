// ContatoCRMOperadorGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { ContatoCRMOperadorGridAdapter } from '@/app/GerAdv_TS/ContatoCRMOperador/Adapter/ContatoCRMOperadorGridAdapter';
// Mock ContatoCRMOperadorGrid component
jest.mock('@/app/GerAdv_TS/ContatoCRMOperador/Crud/Grids/ContatoCRMOperadorGrid', () => () => <div data-testid='contatocrmoperador-grid-mock' />);
describe('ContatoCRMOperadorGridAdapter', () => {
  it('should render ContatoCRMOperadorGrid component', () => {
    const adapter = new ContatoCRMOperadorGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('contatocrmoperador-grid-mock')).toBeInTheDocument();
  });
});