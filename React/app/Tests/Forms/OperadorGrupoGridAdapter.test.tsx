// OperadorGrupoGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { OperadorGrupoGridAdapter } from '@/app/GerAdv_TS/OperadorGrupo/Adapter/OperadorGrupoGridAdapter';
// Mock OperadorGrupoGrid component
jest.mock('@/app/GerAdv_TS/OperadorGrupo/Crud/Grids/OperadorGrupoGrid', () => () => <div data-testid='operadorgrupo-grid-mock' />);
describe('OperadorGrupoGridAdapter', () => {
  it('should render OperadorGrupoGrid component', () => {
    const adapter = new OperadorGrupoGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('operadorgrupo-grid-mock')).toBeInTheDocument();
  });
});