// AlertasEnviadosGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { AlertasEnviadosGridAdapter } from '@/app/GerAdv_TS/AlertasEnviados/Adapter/AlertasEnviadosGridAdapter';
// Mock AlertasEnviadosGrid component
jest.mock('@/app/GerAdv_TS/AlertasEnviados/Crud/Grids/AlertasEnviadosGrid', () => () => <div data-testid='alertasenviados-grid-mock' />);
describe('AlertasEnviadosGridAdapter', () => {
  it('should render AlertasEnviadosGrid component', () => {
    const adapter = new AlertasEnviadosGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('alertasenviados-grid-mock')).toBeInTheDocument();
  });
});