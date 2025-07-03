// EnderecoSistemaGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { EnderecoSistemaGridAdapter } from '@/app/GerAdv_TS/EnderecoSistema/Adapter/EnderecoSistemaGridAdapter';
// Mock EnderecoSistemaGrid component
jest.mock('@/app/GerAdv_TS/EnderecoSistema/Crud/Grids/EnderecoSistemaGrid', () => () => <div data-testid='enderecosistema-grid-mock' />);
describe('EnderecoSistemaGridAdapter', () => {
  it('should render EnderecoSistemaGrid component', () => {
    const adapter = new EnderecoSistemaGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('enderecosistema-grid-mock')).toBeInTheDocument();
  });
});