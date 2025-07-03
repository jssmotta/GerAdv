// StatusAndamentoGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { StatusAndamentoGridAdapter } from '@/app/GerAdv_TS/StatusAndamento/Adapter/StatusAndamentoGridAdapter';
// Mock StatusAndamentoGrid component
jest.mock('@/app/GerAdv_TS/StatusAndamento/Crud/Grids/StatusAndamentoGrid', () => () => <div data-testid='statusandamento-grid-mock' />);
describe('StatusAndamentoGridAdapter', () => {
  it('should render StatusAndamentoGrid component', () => {
    const adapter = new StatusAndamentoGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('statusandamento-grid-mock')).toBeInTheDocument();
  });
});