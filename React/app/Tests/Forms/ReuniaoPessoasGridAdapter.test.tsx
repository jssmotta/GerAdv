// ReuniaoPessoasGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { ReuniaoPessoasGridAdapter } from '@/app/GerAdv_TS/ReuniaoPessoas/Adapter/ReuniaoPessoasGridAdapter';
// Mock ReuniaoPessoasGrid component
jest.mock('@/app/GerAdv_TS/ReuniaoPessoas/Crud/Grids/ReuniaoPessoasGrid', () => () => <div data-testid='reuniaopessoas-grid-mock' />);
describe('ReuniaoPessoasGridAdapter', () => {
  it('should render ReuniaoPessoasGrid component', () => {
    const adapter = new ReuniaoPessoasGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('reuniaopessoas-grid-mock')).toBeInTheDocument();
  });
});