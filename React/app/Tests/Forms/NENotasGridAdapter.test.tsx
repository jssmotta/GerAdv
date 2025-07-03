// NENotasGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { NENotasGridAdapter } from '@/app/GerAdv_TS/NENotas/Adapter/NENotasGridAdapter';
// Mock NENotasGrid component
jest.mock('@/app/GerAdv_TS/NENotas/Crud/Grids/NENotasGrid', () => () => <div data-testid='nenotas-grid-mock' />);
describe('NENotasGridAdapter', () => {
  it('should render NENotasGrid component', () => {
    const adapter = new NENotasGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('nenotas-grid-mock')).toBeInTheDocument();
  });
});