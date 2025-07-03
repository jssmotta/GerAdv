// NECompromissosGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { NECompromissosGridAdapter } from '@/app/GerAdv_TS/NECompromissos/Adapter/NECompromissosGridAdapter';
// Mock NECompromissosGrid component
jest.mock('@/app/GerAdv_TS/NECompromissos/Crud/Grids/NECompromissosGrid', () => () => <div data-testid='necompromissos-grid-mock' />);
describe('NECompromissosGridAdapter', () => {
  it('should render NECompromissosGrid component', () => {
    const adapter = new NECompromissosGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('necompromissos-grid-mock')).toBeInTheDocument();
  });
});