// ViaRecebimentoGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { ViaRecebimentoGridAdapter } from '@/app/GerAdv_TS/ViaRecebimento/Adapter/ViaRecebimentoGridAdapter';
// Mock ViaRecebimentoGrid component
jest.mock('@/app/GerAdv_TS/ViaRecebimento/Crud/Grids/ViaRecebimentoGrid', () => () => <div data-testid='viarecebimento-grid-mock' />);
describe('ViaRecebimentoGridAdapter', () => {
  it('should render ViaRecebimentoGrid component', () => {
    const adapter = new ViaRecebimentoGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('viarecebimento-grid-mock')).toBeInTheDocument();
  });
});