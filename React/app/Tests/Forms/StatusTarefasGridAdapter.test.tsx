// StatusTarefasGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { StatusTarefasGridAdapter } from '@/app/GerAdv_TS/StatusTarefas/Adapter/StatusTarefasGridAdapter';
// Mock StatusTarefasGrid component
jest.mock('@/app/GerAdv_TS/StatusTarefas/Crud/Grids/StatusTarefasGrid', () => () => <div data-testid='statustarefas-grid-mock' />);
describe('StatusTarefasGridAdapter', () => {
  it('should render StatusTarefasGrid component', () => {
    const adapter = new StatusTarefasGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('statustarefas-grid-mock')).toBeInTheDocument();
  });
});